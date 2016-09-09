require 'pty'

class Shop

  def self.create(dir, cmd)
    Dir.chdir(dir) do
      shop = Shop.new(cmd)
      yield(shop)
      shop.close
    end
  end

  def initialize(cmd)
    @stdout, @stdin, @pid = PTY.spawn(cmd)
    get
  end

  def send(s)
    @stdin.write(s + "\n")
    get.split(/\r\n/)[1..-2]
  end

  def close
    put('q')
  end

  private

  def get
    buffer = ''
    buffer += @stdout.readpartial(1024) until buffer =~ /shop> $/
    buffer
  end

  def put(s)
    @stdin.write(s + "\n")
  end
end
